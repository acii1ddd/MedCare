import { isEqualWithTime } from '../../../utils/date.js';

const TimeSlots = ({ slots, onClick, selectedSlot }) => {
    const formatTime = (slot) => {
        return `${slot.getHours()}:${slot.getMinutes() < 10 ? '0' + slot.getMinutes() : slot.getMinutes()}`;
    };
    
    return (
        <div className="max-w-lg mx-auto p-4">
            <h2 className="text-xl font-bold mb-4">Выберите время записи: </h2>

                <ul className="grid grid-cols-3 gap-4">
                    {slots.map((slot, index) => (
                    <li
                        key={index}
                        className={`bg-blue-100 p-3 rounded-lg text-center cursor-pointer hover:bg-blue-200 transition-all
                            ${isEqualWithTime(slot, selectedSlot) ? "ring-4 ring-blue-500 lue-600 font-semibold shadow-md" : ""}
                        `}
                        
                        onClick={() => onClick(slot)}
                    >
                        {formatTime(slot)}
                    </li>
                    ))}
                </ul>
        </div>
    );
}

export default TimeSlots;