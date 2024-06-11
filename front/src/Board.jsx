import { useParams } from 'react-router-dom';
import axios from './lib/axios';
import { useEffect, useState } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import {
  Box,
  Button,
  Heading,
  Input,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  useDisclosure,
  Textarea
} from '@chakra-ui/react';
import { set } from 'lodash';

export default function Board() {
  const { id } = useParams();
  const [lists, setLists] = useState([]);
  const [tasks, setTasks] = useState({});
  const [dataLoaded, setDataLoaded] = useState(false);
  const [newListName, setNewListName] = useState('');
  const [selectedListId, setSelectedListId] = useState(null);
  const { isOpen, onOpen, onClose } = useDisclosure();
  const [newTask, setNewTask] = useState({ title: '', description: '', deadline: '', state: 'To Do' });

  const fetchBoardData = async () => {
    try {
      const listsResponse = await axios.get(`/List/byBoard/${id}`);
      const fetchedLists = listsResponse.data;

      const tasksPromises = fetchedLists.map(list => axios.get(`/Task/byList/${list.id}`));
      const tasksResponses = await Promise.all(tasksPromises);

      const fetchedTasks = tasksResponses.reduce((acc, response, index) => {
        acc[fetchedLists[index].id] = response.data;
        return acc;
      }, {});

      setLists(fetchedLists);
      setTasks(fetchedTasks);
      setDataLoaded(true);
    } catch (error) {
      console.error('Error fetching board data', error);
    }
  };

  useEffect(() => {
    if (!dataLoaded) {
      fetchBoardData();
    }
  }, [dataLoaded]);

  const onDragEnd = async (result) => {
    const { source, destination, draggableId } = result;

    if (!destination) return;

    if (source.droppableId === destination.droppableId) {
      const list = tasks[source.droppableId];
      const newList = Array.from(list);
      const [movedTask] = newList.splice(source.index, 1);
      newList.splice(destination.index, 0, movedTask);

      setTasks(prev => ({ ...prev, [source.droppableId]: newList }));
    } else {
      const sourceList = tasks[source.droppableId];
      const destinationList = tasks[destination.droppableId];

      const newSourceList = Array.from(sourceList);
      const newDestinationList = Array.from(destinationList);

      const [movedTask] = newSourceList.splice(source.index, 1);
      movedTask.listId = parseInt(destination.droppableId);  // Update the listId of the task
      newDestinationList.splice(destination.index, 0, movedTask);

      setTasks(prev => ({
        ...prev,
        [source.droppableId]: newSourceList,
        [destination.droppableId]: newDestinationList,
      }));

      // Update the task's list on the server
      try {
        await axios.put(`/Task/${draggableId}`, movedTask, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        // Refresh the board data after the update
        setTimeout(() => {
            fetchBoardData();
            }, 2000);
      } catch (error) {
        console.error('Error updating task list', error);
      }
    }
  };

  const handleAddList = async () => {
    if (newListName.trim() === '') return;

    const newList = {
      boardId: id,
      name: newListName,
      description: '',
      createdAt: new Date().toISOString(),
      updatedAt: new Date().toISOString(),
    };

    try {
      await axios.post('/List', newList);
      setNewListName('');
      // Refresh the board data after adding the new list
      setTimeout(() => {
      fetchBoardData()
        }
        , 2000);
    } catch (error) {
      console.error('Error adding list', error);
    }
  };

  const handleDeleteList = async (listId) => {
    try {
      await axios.delete(`/List/${listId}`);
      // Refresh the board data after deleting the list
      setTimeout(() => {
      fetchBoardData()
        }
        , 2000);
    } catch (error) {
      console.error('Error deleting list', error);
    }
  };

  const handleAddTask = async () => {
    if (selectedListId == null || newTask.title.trim() === '') return;

    const taskToAdd = {
      ...newTask,
      listId: selectedListId,
      deadline: new Date(newTask.deadline).toISOString(),
    };

    try {
      await axios.post('/Task', taskToAdd);
      onClose();
      setNewTask({ title: '', description: '', deadline: '', state: 'To Do' });
      // Refresh the board data after adding the new task
      setTimeout(() => {
      fetchBoardData()
      }, 2000);
    } catch (error) {
      console.error('Error adding task', error);
    }
  };

  const openTaskModal = (listId) => {
    setSelectedListId(listId);
    onOpen();
  };

  return (
    <Box p={5}>
      <Heading>Board {id}</Heading>
      <Input 
        value={newListName} 
        onChange={(e) => setNewListName(e.target.value)} 
        placeholder="New list name" 
        mt={3}
      />
      <Button onClick={handleAddList} mt={3} colorScheme="teal">Add List</Button>
      {dataLoaded ? (
        <DragDropContext onDragEnd={onDragEnd}>
          <Box display="flex" mt={5}>
            {lists.map(list => (
              <Box key={list.id} borderWidth="1px" borderRadius="lg" p={5} m={2} width="300px">
                <Heading size="md">{list.name}</Heading>
                <Button colorScheme="red" mt={2} onClick={() => handleDeleteList(list.id)}>Delete List</Button>
                <Button colorScheme="blue" mt={2} onClick={() => openTaskModal(list.id)}>Add Task</Button>
                <Droppable droppableId={list.id.toString()}>
                  {(provided) => (
                    <Box {...provided.droppableProps} ref={provided.innerRef} minHeight="100px" mt={4}>
                      {tasks[list.id] && tasks[list.id].map((task, index) => (
                        <Draggable key={task.id} draggableId={task.id.toString()} index={index}>
                          {(provided) => (
                            <Box
                              ref={provided.innerRef}
                              {...provided.draggableProps}
                              {...provided.dragHandleProps}
                              p={4}
                              m={2}
                              borderWidth="1px"
                              borderRadius="lg"
                              bg="white"
                              boxShadow="sm"
                            >
                              <Heading size="sm">{task.title}</Heading>
                              <p>{task.description}</p>
                              <p>Deadline: {new Date(task.deadline).toLocaleString()}</p>
                              <p>State: {task.state}</p>
                            </Box>
                          )}
                        </Draggable>
                      ))}
                      {provided.placeholder}
                    </Box>
                  )}
                </Droppable>
              </Box>
            ))}
          </Box>
        </DragDropContext>
      ) : (
        <p>Loading...</p>
      )}

      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Add Task</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <Input 
              placeholder="Task title" 
              value={newTask.title} 
              onChange={(e) => setNewTask(prev => ({ ...prev, title: e.target.value }))}
              mb={3}
            />
            <Textarea 
              placeholder="Task description" 
              value={newTask.description} 
              onChange={(e) => setNewTask(prev => ({ ...prev, description: e.target.value }))}
              mb={3}
            />
            <Input 
              type="datetime-local" 
              placeholder="Deadline" 
              value={newTask.deadline} 
              onChange={(e) => setNewTask(prev => ({ ...prev, deadline: e.target.value }))}
              mb={3}
            />
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" mr={3} onClick={handleAddTask}>
              Add Task
            </Button>
            <Button variant="ghost" onClick={onClose}>Cancel</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </Box>
  );
}
