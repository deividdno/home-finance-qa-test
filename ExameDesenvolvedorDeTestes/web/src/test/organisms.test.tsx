import { render, screen, fireEvent } from '@testing-library/react';
import { describe, it, expect, vi } from 'vitest';
import { BrowserRouter } from 'react-router-dom';
import { DataTable } from '../components/organisms/DataTable';
import { Sidebar } from '../components/organisms/Sidebar';

// Mock das rotas
vi.mock('../lib/routes', () => ({
  getSidebarRoutes: () => [
    { path: '/', label: 'Home' },
    { path: '/pessoas', label: 'Pessoas' },
  ],
}));

describe('Testes de Nível: Organisms', () => {
  describe('DataTable', () => {
    const mockColumns = [
      { key: 'nome', header: 'Nome' },
      { key: 'valor', header: 'Valor' },
    ];

    const mockData = [{ id: '1', nome: 'Conta de Luz', valor: 150 }];

    it('deve renderizar os dados corretamente', () => {
      render(<DataTable columns={mockColumns as never} data={mockData} />);

      expect(screen.getByText('Conta de Luz')).toBeInTheDocument();
      expect(screen.getByText('150')).toBeInTheDocument();
    });

    it('deve chamar onDelete ao clicar no botão delete', () => {
      const onDelete = vi.fn();

      render(
        <DataTable
          columns={mockColumns as never}
          data={mockData}
          onDelete={onDelete}
        />,
      );

      const deleteBtn = screen.getByLabelText(/Deletar 1/i);

      fireEvent.click(deleteBtn);

      expect(onDelete).toHaveBeenCalledTimes(1);
      expect(onDelete).toHaveBeenCalledWith(mockData[0]);
    });
  });

  describe('Sidebar', () => {
    it('deve renderizar os links de navegação', () => {
      render(
        <BrowserRouter>
          <Sidebar />
        </BrowserRouter>,
      );

      expect(screen.getByText('Home')).toBeInTheDocument();
      expect(screen.getByText('Pessoas')).toBeInTheDocument();
    });
  });
});
