import {
  Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button
} from '@mui/material';

const DataTable = ({ rows, columns, onDelete, onEdit }) => {
  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            {columns.map((col) => (
              <TableCell key={col.field}>{col.headerName}</TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow key={row.id}>
              {columns.map((col) => (
                <TableCell key={col.field}>
                  {col.renderCell
                    ? col.renderCell({ row })
                    : col.valueGetter
                      ? col.valueGetter({ row })
                      : typeof row[col.field] === 'object' && row[col.field] !== null
                        ? JSON.stringify(row[col.field]) // ou qualquer representação desejada
                        : row[col.field]}
                </TableCell>

              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default DataTable;


