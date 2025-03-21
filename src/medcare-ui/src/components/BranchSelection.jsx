export default function BranchSelection({branches, onSelect}) {
    return (
        <div>
            {/* {Выбор филиала} */}
            <h2 className='text-xl font-semibold mb-2'>Выберите филиал: </h2>
            <div className='space-y-2'>
            {
                branches.map((branch, index) => {
                return (
                    <button key={index} onClick={() => onSelect(branch)}
                    className="bg-white text-green-600 px-4 py-2 rounded-lg w-full hover:bg-green-100">
                        {branch}
                    </button>
                );
                }) 
            }
            </div>
        </div> 
    );
}
