import { useState } from "react";
import ServiceList from '../Lists/ServiceList';

export default function Specialization({ specialization }) {

    // хук для отслеживания состояния выпадающего блока с ценами
    const [isOpen, setIsOpen] = useState(false);

    return (
        <div className="specialization">
            <div className="flex justify-between items-center shadow-lg rounded-lg">
                <div className="p-4 w-full text-center mb-3">
                    <div className="specialization-name" onClick={() => setIsOpen(!isOpen)}>
                        <h2 className="text-xl font-semibold hover:text-green-600 duration-300 cursor-pointer">{specialization.name}</h2>
                    </div>
                </div>
                <div className="p-2">
                    <button className="rounded-full text-white" onClick={() => setIsOpen(!isOpen)}>{isOpen ?  "▲" : "▼"}</button>
                </div>
            </div>

            {/* Блок для показа услуг и их цен */}
            <div className="service-list">
                {isOpen && (
                    <ServiceList services={specialization.services}/>
                )}
            </div>
        </div>
    );
}
