export default function Service({ service }) {
    return (
        <tr className="border-b hover:bg-gray-100 transition-all">
            <td className="p-3 text-left">{service.name}</td>
            <td className="p-3 text-left">{service.price}</td>
        </tr>
    );
}
