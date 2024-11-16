const RadioField = ({ options, selectedValue, onChange, className, name }) => {
    const handleOptionChange = (event) => {
        onChange(event.target.value);
    };

    return (
        <div className={`flex justify-start w-full ${className}`}>
            {options.map((option) => (
                <label key={option.value} className="ml-2">
                    <input
                        name={name}
                        type="radio"
                        value={option.value}
                        checked={selectedValue === option.value}
                        onChange={handleOptionChange}
                    />
                    <span className="ml-2">{option.label}</span>
                </label>
            ))}
        </div>
    );
};

export default RadioField;