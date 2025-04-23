import { useEffect, useState } from 'react';
import { BarChart, Bar, XAxis, YAxis, Tooltip, CartesianGrid, ResponsiveContainer } from 'recharts';

export default function PopularSpecializationsChart() {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7009/api/appointments/popular-specializations')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Ошибка при загрузке данных для статистики по популярным специализациям');
                }
                return response.json();
            })
            .then(json => {
                setData(json);
            })
            .catch(error => {
                console.error('Ошибка при загрузке данных:', error);
            });
    }, []);

    
    // Число приемов к врачам данной специализации  
    return (
        <div className="p-4">
            <ResponsiveContainer width="100%" height={400}>
                <BarChart data={data}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <YAxis 
                        label={{ 
                            value: 'Число приёмов', 
                            angle: -90, 
                            position: 'center', 
                            offset: 10,
                            dx: -20 
                        }} 
                    />
                    <XAxis
                        dataKey="specializationName"
                        label={{ 
                            value: 'Специализация', 
                            position: 'insideBottomRight', 
                            dy: 0, 
                            dx: -10, 
                            style: { textAnchor: 'end' }
                        }}
                    />
                    <Tooltip formatter={(value) => `${value} приём(ов)`} />
                    <Bar dataKey="appointmentCount" fill="#8884d8" />
                </BarChart>
            </ResponsiveContainer>
        </div>
    );
}
