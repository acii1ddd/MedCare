import { useEffect, useState } from 'react';
import { PieChart, Pie, Cell, Tooltip, Legend, ResponsiveContainer } from 'recharts';

export default function PopularDoctorsChart() {
    const [doctors, setDoctors] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7009/api/appointments/popular-doctors')
            .then(response => response.json())
            .then(data => setDoctors(data))
            .catch(error => console.error('Ошибка при загрузке данных о самых популярных врачах:', error));
    }, []);

    const chartData = doctors.map(doctor => ({
        name: doctor.doctorName,
        value: doctor.appointmentCount
    }));

    const COLORS = ['#8884d8', '#82ca9d', '#ffc658', '#ff8042', '#d0ed57'];

    return (
        <div className="p-4">
            <ResponsiveContainer width="100%" height={400}>
                <PieChart>
                    <Pie
                        data={chartData}
                        dataKey="value"
                        nameKey="name"
                        cx="50%"
                        cy="50%"
                        outerRadius={150}
                        label
                    >
                        {chartData.map((entry, index) => (
                            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                        ))}
                    </Pie>
                    <Tooltip formatter={(value) => `${value} приём(ов)`} />
                    <Legend />
                </PieChart>
            </ResponsiveContainer>
        </div>
    );
}
