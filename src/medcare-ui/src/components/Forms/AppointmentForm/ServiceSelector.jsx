import { useEffect, useState } from "react";
import GetSpecializationsForBranch from "../../../services/services.js";
import Service from '../../Items/Service.jsx';

const ServiceSelector = ({ selectedBranch, selectedSpecialization, setSelectedService }) => {
    if (!selectedBranch) throw new Error("Параметр selectedBranch не определен");
    if (!selectedSpecialization) throw new Error("Параметр selectedBranch не определен");

    const [services, setServices] = useState([]);
    const [selectedServiceState, setSelectedServiceState] = useState(null);

    useEffect(() => {
        const fetchServices = async () => {
            const services = await GetSpecializationsForBranch(selectedBranch.id, selectedSpecialization.id);
            setServices(services);
        }

        fetchServices();
    }, [selectedBranch.id, selectedSpecialization.id]);
    
    const serviceClickHandler = (service) => {
        setSelectedServiceState(service);
        setSelectedService(service);
    };

    return (
        <div className="service-list">
            <div className="mt-3 bg-gray-300 p-3 rounded shadow-md">
                <table className="min-w-full table-auto border-collapse">
                    <thead className="bg-gray-200">
                        <tr>
                            <td className="p-3 text-left text-sm font-semibold text-gray-700">Наименование услуги</td>
                            <td className="p-3 text-left text-sm font-semibold text-gray-700">Цена</td>
                            <td className="p-3 text-left text-sm font-semibold text-gray-700 w-[100px]"></td>
                        </tr>
                    </thead>
                    <tbody>
                    {services.map((service) => (
                        <Service key={service.id} service={service} onClick={serviceClickHandler} isSelected={selectedServiceState?.id === service.id}/>
                    ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default ServiceSelector;