import { useEffect, useState } from 'react';
import axios from './lib/axios';
import {
  Flex,
  Heading,
  Grid,
  GridItem,
  Box,
  Link,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  useDisclosure,
  Input,
  Textarea,
  Button,
  Text
} from '@chakra-ui/react';

export default function Boards() {
  const [boards, setBoards] = useState([]);
  const [boardsLoaded, setBoardsLoaded] = useState(false);
  const [newBoard, setNewBoard] = useState({ name: '', description: '' });
  const { isOpen, onOpen, onClose } = useDisclosure();

  const fetchBoards = async () => {
    try {
      const response = await axios.get('/Board');
      setBoards(response.data);
      setBoardsLoaded(true);
    } catch (error) {
      console.error('Error fetching boards:', error);
    }
  };

  useEffect(() => {
    if (!boardsLoaded) {
      fetchBoards();
    }
  }, [boardsLoaded]);

  const handleAddBoard = async () => {
    try {
      const response = await axios.post('/Board', newBoard);
      const createdBoard = response.data;
      setNewBoard({ name: '', description: '' }); // Reset the form
      onClose(); // Close the modal
      fetchBoards(); // Refresh boards after adding new board
    } catch (error) {
      console.error('Error adding board:', error);
    }
  };

  return (
    <>
      <Flex p={4} bg="gray.100" justify="space-between">
        <Heading size="md">Boards</Heading>
        <Link onClick={onOpen}>Create board</Link>
      </Flex>

      <Flex direction="column" p={4} flex="1">
        <Grid templateColumns="repeat(3, 1fr)" gap={6}>
          {boards.map((board) => (
            <Link href={`/board/${board.id}`} key={board.id}>
              <GridItem>
                <Box p={4} borderWidth="1px" borderRadius="lg" boxShadow="md" bg="white">
                  <Heading size="md">{board.name}</Heading>
                  <Text>{board.description}</Text>
                </Box>
              </GridItem>
            </Link>
          ))}
        </Grid>
      </Flex>

      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Add New Board</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <Input
              placeholder="Board Name"
              value={newBoard.name}
              onChange={(e) => setNewBoard({ ...newBoard, name: e.target.value })}
              mb={3}
            />
            <Textarea
              placeholder="Board Description"
              value={newBoard.description}
              onChange={(e) => setNewBoard({ ...newBoard, description: e.target.value })}
              mb={3}
            />
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" mr={3} onClick={handleAddBoard}>
              Add Board
            </Button>
            <Button variant="ghost" onClick={onClose}>
              Cancel
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
}
