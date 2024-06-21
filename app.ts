
import express, { Request, Response } from 'express';
import bodyParser from 'body-parser';
import fs from 'fs';

const app = express();
const PORT = 3000;
const dataFile = './data.json';

app.use(bodyParser.json());

app.post('/api/save-data', (req: Request, res: Response) => {
  const { formData } = req.body;
  if (!formData) {
    return res.status(400).send('Invalid data');
  }

  try {
    let currentData = [];
    if (fs.existsSync(dataFile)) {
      const rawData = fs.readFileSync(dataFile, 'utf8');
      currentData = JSON.parse(rawData);
    }
    currentData.push(formData);
    fs.writeFileSync(dataFile, JSON.stringify(currentData, null, 2));
    res.sendStatus(200);
  } catch (err) {
    console.error(err);
    res.status(500).send('Server error');
  }
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});

