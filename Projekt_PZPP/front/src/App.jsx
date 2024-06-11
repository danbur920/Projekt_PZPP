import './App.css'
import { Box, Flex, Heading } from '@chakra-ui/react';
import Boards from './Boards'


function App() {

  return (
    <>
    <Flex direction="column" minH="100vh">
        <Box bg="teal.500" w="100%" p={4} color="white">
          <Heading size="lg">ELLO</Heading>
        </Box>
        <Boards />
      </Flex>
      
    </>
  )
}

export default App
