export default function Service({ service }) {
    return (
        <div className="service-card border p-4 rounded-lg shadow-lg max-w-xs mx-auto">
            <div className="service-info text-center mb-4">
                <h2 className="text-2xl font-semibold">
                    {service.name} {service.price}
                </h2>
            </div>
        </div>
    );
}
