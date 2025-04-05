import { useState } from "react";
import DayCell from "./DayCell";

export default function Calendar({ availableDays }) {
    const [monthOffset, setMonthOffset] = useState(0);
    const today = new Date();
    const currentDate = new Date(today.getFullYear(), today.getMonth() + monthOffset);
    const currentMonth = currentDate.getMonth();
    const currentYear = currentDate.getFullYear();

    const daysInMonth = new Date(currentYear, currentMonth + 1, 0).getDate();
    const startDayOfWeek = new Date(currentYear, currentMonth, 1).getDay();
    const days = Array.from({ length: daysInMonth }, (_, i) => i + 1);
    const weekDays = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];

    return (
        <div>
          <div className="flex justify-between items-center mb-2">
            <button onClick={() => setMonthOffset((m) => m - 1)}>&larr;</button>
            <span className="font-bold">
              {currentDate.toLocaleString("ru-RU", { month: "long", year: "numeric" })}
            </span>
            <button onClick={() => setMonthOffset((m) => m + 1)}>&rarr;</button>
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
              <DayCell key={day} day={day} isAvailable={availableDays.includes(day)} />
            ))}
          </div>
        </div>
    );
}
