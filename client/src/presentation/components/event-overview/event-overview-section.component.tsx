import { EventOverview } from "./children/event-overview.component"
import { useEffect, useState } from "react"

export const EventOverviewSection = () => {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(`http://localhost:5220/api/events` );
                if (!response.ok) throw new Error('Network response was not ok');
                const result = await response.json();
                console.log(result)
                setData(result);
            } catch (err)
            {
                setError(err);
            } finally {
                setLoading(false);
            }
        };
        fetchData();
    }, []);


    useEffect(() => {
        console.log(data)
    }, [data, loading, error]);

    return <div className="flex max-w-full w-full h-[20rem] my-4">
        <EventOverview heading="Tulevased uritused" data={data} className="basis-[50%] mr-4 shrink-0" actions={<button className="font-bold text-xs text-textPrimary">LISA ÜRITUS</button>} />
        <EventOverview heading="Toimunud uritused" className="basis-[50%]" />
    </div>
}



