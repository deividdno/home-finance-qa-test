import { render, screen } from '@testing-library/react';
import { describe, it, expect, vi } from 'vitest';
import { TransacaoForm } from '../components/molecules/TransacaoForm';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const queryClient = new QueryClient();

vi.mock('@/hooks/useTransacoes', () => ({
  useCreateTransacao: () => ({ mutateAsync: vi.fn(), isPending: false }),
}));

describe('Testes de Nível: Molecules', () => {
  it('deve exibir aviso de restrição para menores no formulário de transação', () => {
    render(
      <QueryClientProvider client={queryClient}>
        <TransacaoForm onSuccess={() => {}} onCancel={() => {}} />
      </QueryClientProvider>,
    );

    const aviso = screen.queryByText(/Menores só podem registrar despesas/i);
    expect(aviso).toBeDefined();
  });
});
