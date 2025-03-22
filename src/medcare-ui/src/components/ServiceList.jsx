import { useEffect, useState } from "react";
import Service from "./Service";
import GetServicesByBranch from '../services/services';

export default function ServiceList({ branchName }) {
    // Состояние для списка услуг
    const [services, setServices] = useState([]);

    useEffect(() => {
        const fetchServices = async () => {
            const services = await GetServicesByBranch(branchName);
            setServices(services);   // компонент ServiceList перерендеривается
        };

        fetchServices();

    }, [branchName]); // зависим от branchName

    return (
        <div className="service-list">
            <p className="text-3xl font-semibold mb-4">Услуги:</p>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
                {
                    services.map((service) => {
                        return <Service key={service.id} service={service}/>;
                    })
                }
            </div>
        </div>
    );
}