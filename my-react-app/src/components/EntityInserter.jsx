import { useState } from "react";
import { Box, Flex, Text, Input, Button } from "@chakra-ui/react";


const ENTITIES = {
  Intern: {
    endpoint: "AddIntern",
    fields: [
      { key: "schoolId", label: "School ID", type: "number" },
      { key: "internshipId", label: "Internship ID", type: "number" },
      { key: "firstName", label: "First Name", type: "text" },
      { key: "lastName", label: "Last Name", type: "text" },
    ],
  },
  Internship: {
    endpoint: "AddInternship",
    fields: [
      { key: "organizationId", label: "Organization ID", type: "number" },
      { key: "partnerId", label: "Partner ID", type: "number" },
      { key: "schoolId", label: "School ID", type: "number" },
      { key: "description", label: "Description", type: "text" },
    ],
  },
  Interview: {
    endpoint: "AddInterview",
    fields: [
      { key: "internshipId", label: "Internship ID", type: "number" },
      { key: "internId", label: "Intern ID", type: "number" },
      { key: "mentorId", label: "Mentor ID", type: "number" },
      { key: "interviewDate", label: "Interview Date", type: "date" },
    ],
  },
  Mentor: {
    endpoint: "AddMentor",
    fields: [
      { key: "organizationId", label: "Organization ID", type: "number" },
      { key: "firstName", label: "First Name", type: "text" },
      { key: "lastName", label: "Last Name", type: "text" },
    ],
  },
  Organization: {
    endpoint: "AddOrganization",
    fields: [{ key: "name", label: "Name", type: "text" }],
  },
  OrganizationRepresentative: {
    endpoint: "AddOrganizationRepresentative",
    fields: [
      { key: "organizationId", label: "Organization ID", type: "number" },
      { key: "firstName", label: "First Name", type: "text" },
      { key: "lastName", label: "Last Name", type: "text" },
    ],
  },
  Partner: {
    endpoint: "AddPartner",
    fields: [{ key: "name", label: "Name", type: "text" }],
  },
  PartnerRepresentative: {
    endpoint: "AddPartnerRepresentative",
    fields: [
      { key: "partnerId", label: "Partner ID", type: "number" },
      { key: "firstName", label: "First Name", type: "text" },
      { key: "lastName", label: "Last Name", type: "text" },
    ],
  },
  School: {
    endpoint: "AddSchool",
    fields: [{ key: "name", label: "Name", type: "text" }],
  },
  SchoolRepresentative: {
    endpoint: "AddSchoolRepresentative",
    fields: [
      { key: "schoolId", label: "School ID", type: "number" },
      { key: "firstName", label: "First Name", type: "text" },
      { key: "lastName", label: "Last Name", type: "text" },
    ],
  },
};

function EntityInserter({ onInserted }) {
  const [selected, setSelected] = useState(null);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [values, setValues] = useState({});
  const [status, setStatus] = useState(null);

  const entity = selected ? ENTITIES[selected] : null;

  const isValid =
    entity &&
    entity.fields.every((f) => {
      const v = values[f.key];
      if (!v && v !== 0) return false;
      if (f.type === "number") return !isNaN(Number(v)) && v !== "";
      return v.trim() !== "";
    });

  const handleSelect = (name) => {
    setSelected(name);
    setDropdownOpen(false);
    setValues({});
    setStatus(null);
  };

  const handleChange = (key, value) => {
    setValues((prev) => ({ ...prev, [key]: value }));
    setStatus(null);
  };

  const handleSubmit = async () => {
    if (!isValid) return;
    const payload = {};
    entity.fields.forEach((f) => {
      payload[f.key] = f.type === "number" ? Number(values[f.key]) : values[f.key];
    });
    try {
      const res = await fetch(`${API}/${entity.endpoint}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });
      if (res.ok) {
        setStatus("success");
        setValues({});
        if (onInserted) onInserted();
      } else {
        setStatus("error");
      }
    } catch {
      setStatus("error");
    }
  };

  return (
    <Box mb="10">
      <Flex align="flex-end" gap="4" wrap="wrap">
        {/* Dropdown */}
        <Box position="relative">
          <Text fontSize="xs" mb="1" color="gray.500">Entity</Text>
          <Button variant="outline" onClick={() => setDropdownOpen((o) => !o)} minW="200px" justifyContent="space-between">
            {selected ?? "Select entity"} ▾
          </Button>
          {dropdownOpen && (
            <Box position="absolute" top="100%" left="0" mt="1" bg="white" border="1px solid" borderColor="gray.200" borderRadius="md" zIndex="10" minW="200px" boxShadow="md">
              {Object.keys(ENTITIES).map((name) => (
                <Box key={name} px="4" py="2" cursor="pointer" color="black" _hover={{ bg: "gray.100" }} onClick={() => handleSelect(name)}>
                  {name}
                </Box>
              ))}
            </Box>
          )}
        </Box>

        {/* Fields */}
        {entity && entity.fields.map((f) => (
          <Box key={f.key}>
            <Text fontSize="xs" mb="1" color="gray.500">{f.label}</Text>
            <Input
              placeholder={`${f.label}...`}
              type={f.type === "number" ? "number" : f.type === "date" ? "date" : "text"}
              value={values[f.key] ?? ""}
              onChange={(e) => handleChange(f.key, e.target.value)}
              w="140px"
            />
          </Box>
        ))}

        {/* Add button */}
        {entity && (
          <Button colorScheme="blue" disabled={!isValid} onClick={handleSubmit}>+</Button>
        )}
      </Flex>

      {status === "success" && <Text color="green.500" mt="2">Record added successfully.</Text>}
      {status === "error" && <Text color="red.500" mt="2">Something went wrong. Check your IDs and try again.</Text>}
    </Box>
  );
}

export default EntityInserter;