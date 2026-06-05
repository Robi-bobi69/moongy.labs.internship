import { Box, Button, HStack } from "@chakra-ui/react";

function Navbar() {
  return (
    <Box
      p="4"
      borderBottomWidth="1px"
    >
      <HStack gap="4">
        <Button bg="blue.500" color="white">
          Home
        </Button>

        <Button bg="green.500" color="white">
          Internships
        </Button>

        <Button bg="purple.500" color="white">
          Avatars
        </Button>
      </HStack>
    </Box>
  );
}

export default Navbar;