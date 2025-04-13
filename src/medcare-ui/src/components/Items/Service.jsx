const Service = ({ service, onClick, isSelected }) => {
    if (!service) throw new Error("Параметр service не определен");
    
    return (
        <tr
            className={` border-b hover:bg-gray-100 transition-all ${isSelected ? 'bg-blue-100' : ''}`}
        >
            <td className="p-3 text-left">{service.name}</td>
            <td className="p-3 text-left">{service.price}</td>
            <td className="p-3">
                <button 
                    className="min-w-[90px] h-[36px] px-4 py-1 bg-[var(--color_button)] text-white text-sm font-medium
                        rounded-md flex items-center justify-center hover:brightness-110 transition-all duration-200"
                    onClick={() => onClick(service)}
                >
                    Выбрать
                </button>
            </td>
        </tr>
    );
};

export default Service;