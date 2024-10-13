import { useState } from 'react';
import axios from 'axios';

export default function PretragaForma({ setFlights }) {
    const [polazniAerodrom, setPolazakAerodrom] = useState('');
    const [odredisniAerodrom, setOdredisteAerodrom] = useState('');
    const [datumPolaska, setDatumPolaska] = useState('');
    const [datumPovratka, setDatumDolaska] = useState('');
    const [brojPutnika, setBrojPutnika] = useState(1);
    const [valuta, setValuta] = useState('USD');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const response = await axios.get(`api/flights`, {
            params: {
                polazniAerodrom,
                odredisniAerodrom,
                datumPolaska,
                datumPovratka,
                brojPutnika,
                valuta,
            },
        });
        setFlights(response.data);
    };

    return (
        <form onSubmit={handleSubmit}>
            {/* Input fields for the search form */}
        </form>
    );
}
