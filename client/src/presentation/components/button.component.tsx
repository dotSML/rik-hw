type ButtonProps = {
    title: string;
    variant?: 'primary' | 'secondary' | 'danger';
    type?: 'button' | 'submit' | 'reset';
    onClick?: () => void;
    disabled?: boolean;
};

export function Button({ title, variant = 'primary', type = 'button', onClick, disabled = false }: ButtonProps) {
    const baseClasses = "px-4 py-2 font-semibold rounded focus:outline-none";
    let variantClasses = "";

    if (!disabled) {
        switch (variant) {
            case 'primary':
                variantClasses = "bg-blue-500 text-white hover:bg-blue-600";
                break;
            case 'secondary':
                variantClasses = "bg-gray-500 text-white hover:bg-gray-600";
                break;
            case 'danger':
                variantClasses = "bg-red-500 text-white hover:bg-red-600";
                break;
            default:
                variantClasses = "bg-blue-500 text-white hover:bg-blue-600";
                break;
        }
    } else {
        variantClasses = "bg-gray-300 text-gray-700 cursor-not-allowed";
    }

    return (
        <button
            type={type}
            onClick={onClick}
            className={`${baseClasses} ${variantClasses}`}
            disabled={disabled}
        >
            {title}
        </button>
    );
};
