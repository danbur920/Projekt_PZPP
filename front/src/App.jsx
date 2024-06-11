import './App.css'
import { Box, Flex, Heading } from '@chakra-ui/react';
import Boards from './Boards'
import Board from './Board'
import { createBrowserRouter, RouterProvider } from 'react-router-dom';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Boards />
  }, 
  {
    path: '/board/:id',
    element: <Board />
  }

]);

function App() {

  return (
    <>
    <Flex direction="column" minH="100vh">
        <Box bg="teal.500" w="100%" p={4} color="white">
            <Heading size="lg">ELLO</Heading>
        </Box>
        <RouterProvider router={router} />
      </Flex>
      
    </>
  )
}

export default App
