import { IconUserPlus } from '@tabler/icons-react';
import { useNavigate } from 'react-router-dom';
import { Box, Button, Center, Container, Overlay, Stack, Text, Title } from '@mantine/core';

export function HomePage() {
  const navigate = useNavigate();

  return (
    <Box component="main" style={{ position: 'relative', height: '100vh', overflow: 'hidden' }}>
      {/* Видео-фон: используем твой файл main-bg.webm */}
      <video
        autoPlay
        muted
        loop
        poster="/poster.jpg"
        playsInline
        style={{
          position: 'absolute',
          top: 0,
          left: 0,
          width: '100%',
          height: '100%',
          objectFit: 'cover',
          zIndex: -1,
        }}
      >
        {/* Сначала предлагаем оптимизированный WebM, потом MP4 как запасной вариант */}
        <source src="/main-bg-optimized.webm" type="video/webm" />
        <source src="/main-bg.mp4" type="video/mp4" />
      </video>

      {/* Затемнение: в v8 используем opacity (backgroundOpacity больше нет) */}
      <Overlay color="#000" opacity={0.4} zIndex={0} />

      <Container h="100%" style={{ position: 'relative', zIndex: 1 }}>
        <Center h="100%">
          <Stack align="center" gap="xl">
            {' '}
            {/* gap вместо spacing */}
            <Title
              c="white"
              style={{
                fontSize: 'clamp(2.5rem, 10vw, 5.5rem)',
                textAlign: 'center',
                fontWeight: 900,
                lineHeight: 1,
                textTransform: 'uppercase',
              }}
            >
              ТРИП ПАХРА 6.0
            </Title>
            <Button
              size="xl"
              variant="gradient"
              gradient={{ from: 'blue.6', to: 'cyan.6', deg: 90 }}
              radius="md"
              style={{ transition: 'transform 0.2s ease' }}
              leftSection={<IconUserPlus size={20} />} // Добавили иконку для красоты
              onClick={() => navigate('/register')}
              onMouseEnter={(e) => (e.currentTarget.style.transform = 'scale(1.05)')}
              onMouseLeave={(e) => (e.currentTarget.style.transform = 'scale(1)')}
            >
              Зарегистрироваться
            </Button>
          </Stack>
        </Center>
      </Container>
    </Box>
  );
}
