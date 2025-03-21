import { Link } from 'react-router-dom';

export default function Navbar() {
    return (
        <nav className="bg-white shadow-md px-6 py-3 flex justify-between items-center fixed top-0 left-0 w-full">
          {/* Логотип */}
          <div className="text-black-600 font-bold text-2xl">
            Медицинский Центр
          </div>

          {/* Навигация */}
          <div className="flex space-x-6 text-gray-700 font-medium">
            <Link to="/doctors" className="hover:text-black-600 text-xl duration-350">Врачи</Link>
            <Link to="/services" className="hover:text-black-600 text-xl duration-350">Услуги</Link>
            <Link to="/contacts" className="hover:text-black-600 text-xl duration-350">Контакты</Link>
          </div>

          {/* Кнопки Войти / Зарегистрироваться */}
          <div className="flex space-x-4">
            <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
              Войти
            </button>
            <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
              Зарегистрироваться
            </button>
          </div>
        </nav>
    );
}