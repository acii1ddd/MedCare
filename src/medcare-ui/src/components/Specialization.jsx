export default function Specialization({ specialization }) {
    return (
        <div className="flex-col border p-4 rounded-sm shadow-lg">
            <div className="text-center mb-3">
                <h2 className="text-xl font-semibold hover:text-green-600 duration-300">
                    {specialization.name}
                </h2>
            </div>
            <div className="text-center">
                <h2 className="text-2xl text-[17px]">
                    {specialization.description}
                </h2>
            </div>
        </div>
    );
}
