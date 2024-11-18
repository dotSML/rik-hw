import { useEffect, useState } from 'react';

const useForm = (
  initialValues: Record<string, string>,
  initialValidators: {
    [key: string]: (value: string) => string | undefined;
  } = {}
) => {
  const [values, setValues] = useState<Record<string, string | null>>(initialValues);
  const [errors, setErrors] = useState<Record<string, string | undefined>>({});
  const [isTouched, setIsTouched] = useState(false);
  const [isValid, setIsValid] = useState(false);
  const [validators, setValidators] =
    useState<Record<string, (value: string) => string | undefined>>(initialValidators);

  useEffect(() => {
    if (isTouched) {
      const allValid = Object.keys(validators).every(
        (field) => !validators[field](values[field] || '')
      );
      setIsValid(allValid);
    }
  }, [values, validators, isTouched]);

  const validateField = (name: string, value: string) => {
    if (validators[name]) {
      return validators[name](value);
    }
    return '';
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;

    if (!isTouched) {
      setIsTouched(true);
    }

    setValues((prevValues) => ({ ...prevValues, [name]: value }));

    const error = validateField(name, value);
    setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
  };

  const handleBlur = (
    e: React.FocusEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;

    if (!isTouched) {
      setIsTouched(true);
    }

    const error = validateField(name, value);
    setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
  };

  const handleSubmit =
    <T>(
      submitCallback: (data: T) => void | Promise<void>,
      resetValues = true
    ) =>
    () => {
      const newErrors: Record<string, string | undefined> = {};

      Object.keys(validators).forEach((field) => {
        const error = validateField(field, values[field] || '');
        newErrors[field] = error;
      });

      setErrors(newErrors);

      const allValid = Object.keys(validators).every(
        (field) => !validators[field](values[field] || '')
      );

      if (allValid) {
        submitCallback(values);
        if (resetValues) {
          setValues(initialValues);
        }
        setIsTouched(false);
      }
    };

  const handleSetValues = (data: Record<string, string | null>) => {
    setValues((prevValues) => ({ ...prevValues, ...data }));
  };

  return {
    isValid,
    values,
    errors,
    handleChange,
    handleBlur,
    handleSubmit,
    handleSetValues,
    setValidators,
  };
};

export default useForm;
