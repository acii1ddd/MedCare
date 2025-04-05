export default function BranchSelector({ branches, selectedBranch, setSelectedBranch }) {
    return (
      <>
        <label className="block font-bold">Филиал:</label>
        <select
          value={selectedBranch?.id || ""}
          onChange={(e) => {
                const selectedId = e.target.value;
                const branch = branches.find(b => b.id === selectedId);
                setSelectedBranch(branch)
            }
          }
          className="w-full p-2 border rounded mb-4"
        >
          {
            branches.map((branch) => (
                <option key={branch.id} value={branch.id}>
                    {branch.name}
                </option>
            ))
          }
        </select>
      </>
    );
}
