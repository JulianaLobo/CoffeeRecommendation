# Coffee Recommendation API

## Project Overview

The Coffee Recommendation API is designed to help students who drink coffee to improve their cognitive performance while studying. The API provides recommendations on which type of coffee to drink next and when to drink it based on recent coffee consumption and the optimal caffeine levels for peak mental performance.

### Key Concepts

1. **Optimal Caffeine Levels**:
    - Cognitive benefits of caffeine are evident at 75 mg but plateau above this dose.
    - Negative impacts occur when caffeine levels exceed 300 mg.
    - Optimal caffeine level for peak mental performance is 175 mg for an average user.

2. **Caffeine Half-life**:
    - Caffeine levels decrease in the body over time with a mean half-life of approximately 5 hours.

### API Endpoints

#### 1. Get a list of all coffees
- **Path**: `/v1/coffees`
- **Method**: `GET`
- **Expected return**: JSON array of coffee models

#### 2. Calculate/recommend which coffee to drink next and when to drink it
- **Path**: `/v1/calculate`
- **Method**: `POST`
- **Data**: JSON array of recent coffee consumption model
- **Expected return**: JSON array of coffee recommendations model

### Example Models

#### Coffee Model
```json
{
    "Coffees": [
        { "name": "Black Coffee", "code": "blk" },
        { "name": "Espresso", "code": "esp" },
        { "name": "Cappuccino", "code": "cap" },
        { "name": "Latte", "code": "lat" },
        { "name": "Flat White", "code": "wht" },
        { "name": "Cold Brew", "code": "cld" },
        { "name": "Decaf Coffee", "code": "dec" }
    ]
}
```

#### Recent Coffee Consumption Model
```json
{
    [
        { "code": "blk", "time": 60 },
        { "code": "esp", "time": 360 }
    ]
}
```

#### Coffee Recommendations Model

```json
{
    [
        { "name": "Black Coffee", "code": "blk", "wait": 60 },
        { "name": "Espresso", "code": "esp", "wait": 60 }
    ]
}
```

### Calculation Logic

The API calculates the current caffeine level in the body based on recent coffee consumption and provides recommendations on which coffee to drink next and how long to wait before drinking it.

#### Caffeine Decay Calculation
- **Decay Constant**: 0.1386294 per hour

#### Wait Time Calculation
- If the current caffeine level plus the caffeine of the new coffee exceeds the optimal level (175 mg), the API calculates the wait time using the decay constant.
- The wait time is then converted from hours to minutes.

#### Return Values
- If the recommended wait time is zero, it means the user can drink the coffee immediately.
- If the wait time is greater than zero, it indicates the number of minutes the user must wait before consuming the recommended coffee.

### How to Run

1. Clone the repository:
   ```sh
   git clone https://github.com/JulianaLobo/CoffeeRecommendation.git
   cd coffeerecommendationapi

2. Build the project:
   ```sh
   dotnet build

3. Run the projec:
   ```sh
   dotnet run

4. Access the Swagger UI to test the API:
   ```sh
   https://localhost:7044/swagger/index.html
