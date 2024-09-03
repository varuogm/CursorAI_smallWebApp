import './App.css';
import { useEffect, useState, useCallback } from 'react';

function App() {
  const [quotesData, setQuotesData] = useState([]);

  const fetchQuotesData = () => {
    fetch(process.env.REACT_APP_API_URL)
      .then(response => response.json())
      .then(data => setQuotesData(data))
      .catch(error => console.error('Error fetching quotes data:', error));
  };

  const clearQuotesData = useCallback(() => {
    fetch(`${process.env.REACT_APP_API_URL}/ClearQuotes`, {
      method: 'DELETE',
    })
      .then(response => {
        if (response.ok) {
          setQuotesData([]);
          console.log('Quotes cleared successfully');
          fetchQuotesData();
        } else {
          console.error('Error clearing quotes:', response.statusText);
        }
      })
      .catch(error => console.error('Error clearing quotes data:', error));
  }, []);

  useEffect(() => {
    fetchQuotesData();
    const intervalId = setInterval(fetchQuotesData, 35000);
    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className="App">
      <button onClick={clearQuotesData}>Clear</button>
      <h1>Hi, I am Goyurab</h1>
      {quotesData.length > 0 && (
        <div>
          <h2>Quotes</h2>
          {quotesData.map((item, index) => (
            <div key={index}>
              <p>Summary: {item.summary}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default App;
