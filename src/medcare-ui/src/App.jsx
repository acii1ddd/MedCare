import './App.css'
import DoctorList from './components/DoctorList';

function App() {
  return (
    <>
      <nav className="bg-white shadow-md px-6 py-3 flex justify-between items-center fixed top-0 left-0 w-full">
        {/* Логотип */}
        <div className="text-green-600 font-bold text-lg">
          Медицинский Центр
        </div>

        {/* Навигация */}
        <div className="flex space-x-6 text-gray-700 font-medium">
          <a href="#" className="hover:text-green-600">Услуги</a>
          <a href="#" className="hover:text-green-600">Врачи</a>
          <a href="#" className="hover:text-green-600">Цены</a>
        </div>

        {/* Кнопки Войти / Зарегистрироваться */}
        <div className="flex space-x-4">
          <button className="border border-gray-300 px-4 py-2 rounded-lg hover:bg-gray-100">
            Войти
          </button>
          <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
            Зарегистрироваться
          </button>
        </div>
      </nav>
      <main>
        <DoctorList>
          
        </DoctorList>
      </main>
    </>
  );
}

export default App
