import Service from "../Items/Service";

export default function ServiceList({ services }) {
    return (
        <div className="service-list">
            <div className="mt-3 bg-gray-300 p-3 rounded shadow-md">
                {services.length > 0 ? (
                    <table className="min-w-full table-auto border-collapse">
                        <thead className="bg-gray-200">
                            <tr>
                                <td className="p-3 text-left text-sm font-semibold text-gray-700">Наименование услуги</td>
                                <td className="p-3 text-left text-sm font-semibold text-gray-700">Цена</td>
                            </tr>
                        </thead>
                        <tbody>
                        {services.map((service) => (
                            <Service key={service.id} service={service}/>
                        ))}
                        </tbody>
                    </table>
                ) : (
                    <p className="text-gray-500">Услуги загружаются...</p>
                )}
            </div>
        </div>
    );
}