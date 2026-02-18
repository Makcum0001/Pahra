import { IconArrowLeft } from '@tabler/icons-react'; // Не забудь установить @tabler/icons-react
import { useNavigate } from 'react-router-dom';
import {
  ActionIcon,
  Box,
  Button,
  Container,
  Paper,
  Stack,
  TextInput,
  Title,
  Tooltip,
} from '@mantine/core';
import { DateInput } from '@mantine/dates';
import { useForm } from '@mantine/form';

export function RegisterPage() {
  const navigate = useNavigate();

  // Инициализация формы с валидацией
  const form = useForm({
    initialValues: {
      fullName: '',
      phone: '',
      birthDate: null as Date | null,
    },

    validate: {
      fullName: (value) => (value.length < 2 ? 'Введите полное ФИО' : null),
      phone: (value) =>
        /^\+?[0-9]{10,12}$/.test(value.replace(/\s/g, '')) ? null : 'Неверный формат номера',
      birthDate: (value) => (value === null ? 'Укажите дату рождения' : null),
    },
  });

  const handleSubmit = (values: typeof form.values) => {
    console.log('Данные формы:', values);
    // Здесь будет логика отправки на бэкенд
    alert('Заявка отправлена!');
  };

  return (
    <Box
      style={{ minHeight: '100vh', background: 'var(--mantine-color-dark-8)', paddingTop: '50px' }}
    >
      <Container size="xs">
        {/* Кнопка назад */}
        <Tooltip label="Вернуться на главную">
          <ActionIcon variant="subtle" color="gray" mb="lg" onClick={() => navigate('/')} size="lg">
            <IconArrowLeft size={24} />
          </ActionIcon>
        </Tooltip>

        <Paper withBorder shadow="xl" p={40} radius="md" bg="var(--mantine-color-dark-6)">
          <Stack gap="xs" mb={30}>
            <Title order={2} c="white" ta="center">
              Анкета участника
            </Title>
            <Title order={5} c="gray.5" ta="center" fw={400}>
              Трип Пахра 6.0
            </Title>
          </Stack>

          <form onSubmit={form.onSubmit(handleSubmit)}>
            <Stack gap="md">
              <TextInput
                label="ФИО"
                placeholder="Иванов Иван Иванович"
                required
                withAsterisk
                {...form.getInputProps('fullName')}
              />

              <TextInput
                label="Номер телефона"
                placeholder="+7 999 000 00 00"
                required
                withAsterisk
                {...form.getInputProps('phone')}
              />

              <DateInput
                label="Дата рождения"
                placeholder="Выберите дату"
                required
                clearable
                valueFormat="DD.MM.YYYY"
                {...form.getInputProps('birthDate')}
              />

              <Button
                type="submit"
                fullWidth
                size="lg"
                mt="xl"
                variant="gradient"
                gradient={{ from: 'blue.6', to: 'cyan.6' }}
              >
                Отправить данные
              </Button>
            </Stack>
          </form>
        </Paper>
      </Container>
    </Box>
  );
}
