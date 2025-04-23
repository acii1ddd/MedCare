import { useEffect, useState } from 'react';
import { PieChart, Pie, Cell, Tooltip, Legend, ResponsiveContainer } from 'recharts';

const COLORS = ["#34D399", "#60A5FA", "#FBBF24", "#F87171", "#A78BFA"];

export default function PopularServicesPieChart() {
    const [services, setServices] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7009/api/appointments/popular-services')
            .then(response => response.json())
            .then(data => setServices(data))
            .catch(error => console.error('Ошибка при загрузке данных о самых популярных услугах:', error));
    }, []);

    return (
        <div className="bg-white p-6 rounded-2xl shadow-md">
            <ResponsiveContainer width="100%" height={300}>
                <PieChart>
                    <Pie
                        data={services}
                        dataKey="appointmentCount"
                        nameKey="serviceName"
                        cx="50%"
                        cy="50%"
                        outerRadius={100}
                        label
                    >
                        {services.map((entry, index) => (
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
