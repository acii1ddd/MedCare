const Note = ({ value, handleChange }) => {
    return (
        <>
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Примечание
                </label>
                <textarea
                    name="note"
                    value={value}
                    onChange={handleChange}
                    rows="3"
                    className="w-full border border-gray-300 rounded p-2"
                />
            </div>
        </>
    );
};

export default Note;