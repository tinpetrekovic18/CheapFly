import { useTable } from 'react-table';

export default function LetoviTablica({ flights }) {
    const columns = React.useMemo(
        () => [
            { Header: 'Departure Airport', accessor: 'departureAirport' },
            { Header: 'Arrival Airport', accessor: 'arrivalAirport' },
            { Header: 'Departure Date', accessor: 'departureDate' },
            { Header: 'Return Date', accessor: 'returnDate' },
            { Header: 'Layovers', accessor: 'layovers' },
            { Header: 'Passenger Count', accessor: 'passengerCount' },
            { Header: 'Currency', accessor: 'currency' },
            { Header: 'Total Price', accessor: 'totalPrice' },
        ],
        []
    );

    const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = useTable({ columns, data: flights });

    return (
        <table {...getTableProps()}>
            <thead>
                {headerGroups.map(headerGroup => (
                    <tr {...headerGroup.getHeaderGroupProps()}>
                        {headerGroup.headers.map(column => (
                            <th {...column.getHeaderProps()}>{column.render('Header')}</th>
                        ))}
                    </tr>
                ))}
            </thead>
            <tbody {...getTableBodyProps()}>
                {rows.map(row => {
                    prepareRow(row);
                    return (
                        <tr {...row.getRowProps()}>
                            {row.cells.map(cell => {
                                return <td {...cell.getCellProps()}>{cell.render('Cell')}</td>;
                            })}
                        </tr>
                    );
                })}
            </tbody>
        </table>
    );
}
