type ButtonProps = {
  title: string;
  variant?: 'primary' | 'secondary' | 'danger' | 'text';
  type?: 'button' | 'submit' | 'reset';
  onClick?: () => void;
  disabled?: boolean;
  size?: 'xs' | 'sm' | 'md' | 'lg';
  className?: string;
};

export function Button({
  title,
  variant = 'primary',
  type = 'button',
  onClick,
  disabled = false,
  size = 'md',
  className,
}: ButtonProps) {
  const baseClasses = `px-4 py-2 font-semibold rounded focus:outline-none text-${size}`;
  let variantClasses = '';

  if (!disabled) {
    switch (variant) {
      case 'primary':
        variantClasses = 'bg-blue-500 text-white hover:bg-blue-600';
        break;
      case 'secondary':
        variantClasses = 'bg-gray-500 text-white hover:bg-gray-600';
        break;
      case 'danger':
        variantClasses = 'bg-red-500 text-white hover:bg-red-600';
        break;
      case 'text':
        variantClasses =
          'bg-transparent text-text-primary hover:text-text-secondary';
        break;
      default:
        variantClasses = 'bg-blue-500 text-white hover:bg-blue-600';
        break;
    }
  } else {
    variantClasses = 'bg-gray-300 text-gray-700 cursor-not-allowed';
  }

  return (
    <button
      type={type}
      onClick={onClick}
      className={`${baseClasses} ${variantClasses} ${className}`}
      disabled={disabled}
    >
      {title}
    </button>
  );
}
