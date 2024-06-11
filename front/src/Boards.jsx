import { useEffect, useState } from 'react'
import './App.css'
import axios from './lib/axios'
import { Link } from '@chakra-ui/react'
import { Text } from '@chakra-ui/react'
import { Box, Flex, Heading, Grid, GridItem } from '@chakra-ui/react';

export default function Boards() {
    const [board, setBoard] = useState([])
    const [boardLoaded, setBoardLoaded] = useState(false)
  
    const fetchBoard = async () => {
      const response = await axios.get('/Board')
      setBoard(response.data)
      setBoardLoaded(true)
    }
  
    useEffect(() => {
      if(!boardLoaded)
        fetchBoard()
    }, [])

    return (
    <>
        <Flex p={4} bg="gray.100" justify="space-between">
        <Heading size="md">Boards</Heading>
        <Link href="/board/new">Create board</Link>
        </Flex>

        <Flex direction="column" p={4} flex="1">
        <Grid templateColumns="repeat(3, 1fr)" gap={6}>
        {board.map((board) => (
            <Link href={`/board/${board.id}`} key={board.id}>
            <GridItem >
            <Box
                p={4}
                borderWidth="1px"
                borderRadius="lg"
                boxShadow="md"
                bg="white"
            >
                <Heading size="md">{board.name}</Heading>
                <Text>{board.description}</Text>
            </Box>
            </GridItem>
            </Link>
        ))}
        </Grid>
        </Flex> 
    </>
)
}
