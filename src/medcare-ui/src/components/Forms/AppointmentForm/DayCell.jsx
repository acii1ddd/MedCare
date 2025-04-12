export default function DayCell({ day, isAvailable, onClick }) {
    return (
      <div
        className={`w-10 h-10 flex items-center justify-center border rounded ${
          isAvailable ? "bg-green-300" : "bg-gray-100"} ${
            isAvailable ? "cursor-pointer" : ""}`
        }
        onClick={() => onClick(day)}
      >
        {day.getDate()}
      </div>
    );
}