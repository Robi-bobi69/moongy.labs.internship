import Navbar from "../components/Navbar";
import { useEffect, useState } from "react";
import { Box, Heading, Text, Stack, Card, Separator, Flex, Input, Button } from "@chakra-ui/react";

const API = "https://localhost:7226/home";

// ── ENTITY DEFINITIONS ───────────────────────────────────────────────────────
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

// ── HELPERS ──────────────────────────────────────────────────────────────────
function useEntity(endpoint) {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`${API}/${endpoint}`)
      .then((r) => r.json())
      .then((d) => { setData(d); setLoading(false); })
      .catch(() => setLoading(false));
  }, [endpoint]);

  return { data, loading };
}

function EntitySection({ title, children }) {
  return (
    <Box mb="10">
      <Heading size="lg" mb="4">{title}</Heading>
      <Separator mb="4" />
      {children}
    </Box>
  );
}

function EmptyOrLoading({ loading }) {
  return <Text color="gray.500">{loading ? "Loading..." : "No records found."}</Text>;
}

// ── INSERTER ─────────────────────────────────────────────────────────────────
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

// ── HOME PAGE ─────────────────────────────────────────────────────────────────
function Home() {
  const interns = useEntity("GetInterns");
  const internships = useEntity("GetInternships");
  const interviews = useEntity("GetInterviews");
  const mentors = useEntity("GetMentor");
  const organizations = useEntity("GetOrganizations");
  const orgReps = useEntity("GetOrganizationRepresentatives");
  const partners = useEntity("GetPartners");
  const partnerReps = useEntity("GetPartnerRepresentatives");
  const schools = useEntity("GetSchools");
  const schoolReps = useEntity("GetSchoolRepresentatives");

  return (
    <Box p="8">
      <Navbar />

      {/* ── INSERTER - sits between Navbar and the viewer below ── */}
      <EntityInserter onInserted={() => window.location.reload()} />

      {/* ── DATABASE VIEWER - your existing code below, unchanged ── */}

      {/* Interns */}
      <EntitySection title="Interns">
        {interns.loading || interns.data.length === 0
          ? <EmptyOrLoading loading={interns.loading} />
          : <Stack gap="4">
              {interns.data.map((i) => (
                <Card.Root key={i.internId}>
                  <Card.Body>
                    <Heading size="md">{i.firstName} {i.lastName}</Heading>
                    <Text>Intern ID: {i.internId}</Text>
                    <Text>School ID: {i.schoolId}</Text>
                    <Text>Internship ID: {i.internshipId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Internships */}
      <EntitySection title="Internships">
        {internships.loading || internships.data.length === 0
          ? <EmptyOrLoading loading={internships.loading} />
          : <Stack gap="4">
              {internships.data.map((i) => (
                <Card.Root key={i.internshipId}>
                  <Card.Body>
                    <Heading size="md">Internship #{i.internshipId}</Heading>
                    <Text>Organization ID: {i.organizationId}</Text>
                    <Text>Partner ID: {i.partnerId}</Text>
                    <Text>School ID: {i.schoolId}</Text>
                    <Text>Description: {i.description}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Interviews */}
      <EntitySection title="Interviews">
        {interviews.loading || interviews.data.length === 0
          ? <EmptyOrLoading loading={interviews.loading} />
          : <Stack gap="4">
              {interviews.data.map((i) => (
                <Card.Root key={i.interviewId}>
                  <Card.Body>
                    <Heading size="md">Interview #{i.interviewId}</Heading>
                    <Text>Intern ID: {i.internId}</Text>
                    <Text>Mentor ID: {i.mentorId}</Text>
                    <Text>Internship ID: {i.internshipId}</Text>
                    <Text>Date: {new Date(i.interviewDate).toLocaleDateString()}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Mentors */}
      <EntitySection title="Mentors">
        {mentors.loading || mentors.data.length === 0
          ? <EmptyOrLoading loading={mentors.loading} />
          : <Stack gap="4">
              {mentors.data.map((m) => (
                <Card.Root key={m.mentorId}>
                  <Card.Body>
                    <Heading size="md">{m.firstName} {m.lastName}</Heading>
                    <Text>Mentor ID: {m.mentorId}</Text>
                    <Text>Organization ID: {m.organizationId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Organizations */}
      <EntitySection title="Organizations">
        {organizations.loading || organizations.data.length === 0
          ? <EmptyOrLoading loading={organizations.loading} />
          : <Stack gap="4">
              {organizations.data.map((o) => (
                <Card.Root key={o.organizationId}>
                  <Card.Body>
                    <Heading size="md">{o.name}</Heading>
                    <Text>Organization ID: {o.organizationId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Organization Representatives */}
      <EntitySection title="Organization Representatives">
        {orgReps.loading || orgReps.data.length === 0
          ? <EmptyOrLoading loading={orgReps.loading} />
          : <Stack gap="4">
              {orgReps.data.map((r) => (
                <Card.Root key={r.organizationRepresentativeId}>
                  <Card.Body>
                    <Heading size="md">{r.firstName} {r.lastName}</Heading>
                    <Text>Representative ID: {r.organizationRepresentativeId}</Text>
                    <Text>Organization ID: {r.organizationId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Partners */}
      <EntitySection title="Partners">
        {partners.loading || partners.data.length === 0
          ? <EmptyOrLoading loading={partners.loading} />
          : <Stack gap="4">
              {partners.data.map((p) => (
                <Card.Root key={p.partnerId}>
                  <Card.Body>
                    <Heading size="md">{p.name}</Heading>
                    <Text>Partner ID: {p.partnerId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Partner Representatives */}
      <EntitySection title="Partner Representatives">
        {partnerReps.loading || partnerReps.data.length === 0
          ? <EmptyOrLoading loading={partnerReps.loading} />
          : <Stack gap="4">
              {partnerReps.data.map((r) => (
                <Card.Root key={r.partnerRepresentativeId}>
                  <Card.Body>
                    <Heading size="md">{r.firstName} {r.lastName}</Heading>
                    <Text>Representative ID: {r.partnerRepresentativeId}</Text>
                    <Text>Partner ID: {r.partnerId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* Schools */}
      <EntitySection title="Schools">
        {schools.loading || schools.data.length === 0
          ? <EmptyOrLoading loading={schools.loading} />
          : <Stack gap="4">
              {schools.data.map((s) => (
                <Card.Root key={s.schoolId}>
                  <Card.Body>
                    <Heading size="md">{s.name}</Heading>
                    <Text>School ID: {s.schoolId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

      {/* School Representatives */}
      <EntitySection title="School Representatives">
        {schoolReps.loading || schoolReps.data.length === 0
          ? <EmptyOrLoading loading={schoolReps.loading} />
          : <Stack gap="4">
              {schoolReps.data.map((r) => (
                <Card.Root key={r.schoolRepresentativeId}>
                  <Card.Body>
                    <Heading size="md">{r.firstName} {r.lastName}</Heading>
                    <Text>Representative ID: {r.schoolRepresentativeId}</Text>
                    <Text>School ID: {r.schoolId}</Text>
                  </Card.Body>
                </Card.Root>
              ))}
            </Stack>
        }
      </EntitySection>

    </Box>
  );
}

export default Home;