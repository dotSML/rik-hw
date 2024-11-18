import { Button } from './button.component';

interface Action {
  variant: 'primary' | 'secondary' | 'danger';
  title: string;
  onClick: () => void;
  isDisabled?: boolean;
}
export function ActionGroup({ actions }: { actions: Action[] }) {
  return (
    <div className="flex gap-2">
      {actions.map((action, idx) => (
        <Button
          key={'action-' + idx}
          disabled={action.isDisabled}
          variant={action.variant}
          title={action.title}
          onClick={action.onClick}
        />
      ))}
    </div>
  );
}
