import { useState } from "react";
import DayCell from "./DayCell";

export default function Calendar({ availableDays, setMonthBorders, onDayClick }) {
    const [monthOffset, setMonthOffset] = useState(0);
    const [selectedDay, setSelectedDay] = useState(null);


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
    const days = Array.from({ length: daysInMonth }, (_, i) => {
      const date = new Date(currentYear, currentMonth, i + 1);
      date.setHours(0, 0, 0, 0);
      return date;
    });
    const weekDays = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];

    const updateMonthBorders = (newOffset) => {
      const today = new Date();
      const newDate = new Date(today.getFullYear(), today.getMonth() + newOffset, 1);
      const startOfMonth = new Date(newDate.getFullYear(), newDate.getMonth(), 1);
      const endOfMonth = new Date(newDate.getFullYear(), newDate.getMonth() + 1, 0);
      setMonthBorders({ startOfMonth, endOfMonth });
    };

    const dayClickHandler = (day) => {
      setSelectedDay(day);
      onDayClick(day);
    }

    const compareDates = (d1, d2) => {
      return d1.getDate() === d2.getDate() &&
             d1.getMonth() === d2.getMonth() &&
             d1.getFullYear() === d2.getFullYear();
    }
    
    const isAvailableCheck = (day) => {
      const todayWithoutTime = new Date();
      todayWithoutTime.setHours(0, 0, 0, 0);

      if (day < todayWithoutTime) {
        return false;
      }

      const isAvailable = availableDays.some(availableDay => {
        return compareDates(availableDay, day);
      });
      
      return isAvailable;
    }

    return (
        <div className="mt-7">
          <div className="flex justify-between items-center mb-2">
            <button
                onClick={() => {
                  const newOffset = monthOffset - 1;
                  if (newOffset >= 0) {
                    setMonthOffset(newOffset);
                    updateMonthBorders(newOffset);
                  }
                }}
                disabled={monthOffset === 0}
                className={`px-2 py-1 rounded text-gray-100 ${monthOffset === 0 ? "" : "hover:bg-gray-200"}`}
            >
                &larr;
            </button>
            <span className="font-bold">
              {currentDate.toLocaleString("ru-RU", { month: "long", year: "numeric" })}
            </span>
            <button onClick={() => {
               const newOffset = monthOffset + 1;
               setMonthOffset(newOffset);
               updateMonthBorders(newOffset);
            }} className={"text-gray-100"}
            >
              &rarr;
            </button>
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
            {days.map((day) => {
              return <div key={day} className="flex justify-center">
                {/* сравниваем дату свободного дня с бека с числом на карточке дня для отображения свободных дней */}
                <DayCell
                  key={day.toISOString()}
                  day={day}
                  isAvailable={isAvailableCheck(day)} 
                  onClick={dayClickHandler}
                  isSelected={compareDates(selectedDay, day)}
                />
              </div>
            })}
          </div>
        </div>
    );
}
