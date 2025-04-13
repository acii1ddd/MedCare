export default function DayCell({ day, isAvailable, onClick, isSelected }) {
    return (
      <div
        className={`w-10 h-10 flex items-center justify-center border rounded 
          ${isAvailable ? "bg-green-300 cursor-pointer" : "bg-gray-100"}
          ${isSelected ? "ring-4 ring-blue-500 font-bold shadow-md" : ""}
          `}
        onClick={isAvailable ? () => onClick(day) : undefined}
      >
        {day.getDate()}
      </div>
    );
}