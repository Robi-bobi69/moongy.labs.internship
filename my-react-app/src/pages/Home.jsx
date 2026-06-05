import Navbar from "../components/Navbar";
import { useEffect, useState } from "react";
import {
  Box,
  Heading,
  Text,
  Stack,
  Card,
} from "@chakra-ui/react";

function Home() {
  const [mentors, setMentors] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7226/home/getmentor")
      .then((response) => {
        console.log("Status:", response.status);
        return response.json();
      })
      .then((data) => {
        console.log("API DATA:", data);
        setMentors(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("NAPAKA:", error);
        setLoading(false);
      });
  }, []);

  return (

    <Box p="8">
      <Navbar /> 
      <Heading mb="6"
      bg="blue.400"
      color="pink.400">
        Mentors
      </Heading>

      {loading && (
        <Text>Loading...</Text>
      )}

      {!loading && mentors.length === 0 && (
        <Text>No mentors found.</Text>
      )}

      <Stack gap="4">
        {mentors.map((mentor) => (
          <Card.Root key={mentor.mentorId}>
            <Card.Body>
              <Heading size="md">
                {mentor.firstName} {mentor.lastName}
              </Heading>

              <Text>
                Mentor ID: {mentor.mentorId}
              </Text>

              <Text>
                Organization ID: {mentor.organizationId}
              </Text>
            </Card.Body>
          </Card.Root>
        ))}
      </Stack>
    </Box>
  );
}

export default Home;