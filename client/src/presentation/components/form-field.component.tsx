export function FormField({ label, name, value, onChange, onBlur, error, type = "text" }) {
    return (
        <div className="flex items-start gap-4 mb-4">
            <label htmlFor={name} className="w-32 text-right pr-2 pt-1">
                {label}
            </label>
            {type === "textarea" ? (
                <textarea
                    className="border border-black flex-grow p-1 rounded-xs"
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                />
            ) : (
                <input
                    className="border border-black flex-grow p-1"
                    type={type}
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                />
            )}
            {error && <p className="text-red-400 mt-2 text-sm">{error}</p>}
        </div>
    );
}
