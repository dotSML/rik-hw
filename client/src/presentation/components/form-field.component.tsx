export function FormField({ label, name, value, onChange, onBlur, error, type = "text", options = [], min }: {min?: string, label: string, name: string, value: string, onChange: (e: any) => void, onBlur: (e: any) => void, error: string, type?: string, options?: { label: string, value: string }[] }) {
    return (
        <div className="grid grid-cols-3 gap-4 mb-4">
            <label htmlFor={name} className="text-left pr-2 pt-1">
                {label}
            </label>
            {type === "textarea" ? (
                <textarea
                    className="border border-black flex-grow p-1 rounded-xs col-span-2"
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                />
            ) : type === "select" ? (
                <select
                    className="border border-black flex-grow p-1 col-span-2"
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                >
                    <option value="" disabled>
                        Vali...
                    </option>
                    {options.map((option) => (
                        <option key={option.value} value={option.value}>
                            {option.label}
                        </option>
                    ))}
                </select>
            ) : (
                <input
                    className="border border-black flex-grow p-1 col-span-2"
                    type={type}
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                    min={min}
                />
            )}
            {error && <p className="text-red-400 mt-2 text-sm col-span-3">{error}</p>}
        </div>
    );
}
