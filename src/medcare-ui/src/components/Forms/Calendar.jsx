import { useState } from "react";
import DayCell from "./DayCell";

export default function Calendar({ availableDays, setMonthBorders }) {
    const [monthOffset, setMonthOffset] = useState(0);

    if (!availableDays) {
      console.error("Пропс availableDays неопределен");
      return null;
    }

    const today = new Date();
    const currentDate = new Date(today.getFullYear(), today.getMonth() + monthOffset);
    const currentMonth = currentDate.getMonth();
    const currentYear = currentDate.getFullYear();

    const daysInMonth = new Date(currentYear, currentMonth + 1, 0).getDate();
    const startDayOfWeek = new Date(currentYear, currentMonth, 1).getDay();
    const days = Array.from({ length: daysInMonth }, (_, i) => i + 1);
    const weekDays = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];

    const updateMonthBorders = (newOffset) => {
      const newDate = new Date(currentDate.getFullYear(), currentDate.getMonth() + newOffset, 1);
      const startOfMonth = new Date(newDate.getFullYear(), newDate.getMonth(), 1);
      const endOfMonth = new Date(newDate.getFullYear(), newDate.getMonth() + 1, 0);
      setMonthBorders({ startOfMonth, endOfMonth });
    };

    return (
        <div>
          <div className="flex justify-between items-center mb-2">
            <button
                onClick={() => {
                  if (monthOffset > 0) {
                    setMonthOffset((m) => m - 1);
                    updateMonthBorders(monthOffset - 1);
                  }
                }}
                disabled={monthOffset === 0}
                className={`px-2 py-1 rounded text-gray-100 ${monthOffset === 0 ? "сursor-not-allowed" : "hover:bg-gray-200"}`}
            >
                &larr;
            </button>
            <span className="font-bold">
              {currentDate.toLocaleString("ru-RU", { month: "long", year: "numeric" })}
            </span>
            <button onClick={() => setMonthOffset((m) => m + 1)} className={"text-gray-100"}>&rarr;</button>
          </div>

          <div className="grid grid-cols-7 gap-2 mb-2">
            {weekDays.map((d) => (
              <div key={d} className="text-center font-semibold">{d}</div>
            ))}
          </div>

          <div className="grid grid-cols-7 gap-2">
            {Array.from({ length: startDayOfWeek }, (_, i) => (
              <div key={`empty-${i}`} />
            ))}
            {days.map((day) => (
              // сравниваем дату свободного дня с бека с числом на карточке дня для отображения свободных дней
              <DayCell key={day} day={day} isAvailable={availableDays.some((availableDay) => availableDay.getDate() === day)} />
            ))}
          </div>
        </div>
    );
}
