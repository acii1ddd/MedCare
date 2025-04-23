import PopularSpecializationsChart from "./PopularSpecializationsChart";
import PopularDoctorsChart from "./PopularDoctorsChart";
import PopularServicesPieChart from "./PopularServicesPieChart";


export default function StatisticsPage() {
    return (
        <div className="mt-15 pt-5">
            <h1 className="text-left mb-3">Статистика</h1>
            <div className="mb-10 p-6 bg-white rounded-2xl shadow-md">
                <h2 className="text-xl font-bold mb-4">Популярность специализаций</h2>
                <PopularSpecializationsChart />
            </div>

            <div className="mb-10 p-6 bg-white rounded-2xl shadow-md">
                <h2 className="text-xl font-bold mb-6">Популярные врачи по числу приёмов</h2>
                <PopularDoctorsChart/>
            </div>
            
            <div className="mb-10 p-6 bg-white rounded-2xl shadow-md">
                <h2 className="text-2xl font-semibold mb-4">Услуги по популярности</h2>
                <PopularServicesPieChart/>
            </div>
        </div>
    )
}