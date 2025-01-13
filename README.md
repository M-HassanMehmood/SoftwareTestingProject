# Complete Automation Testing of Sauce Labs Website

This repository contains a comprehensive automation testing suite for the Sauce Labs website. The test suite is implemented using **Selenium WebDriver** with **C#**, ensuring full coverage of critical functionalities. Below is a detailed breakdown of the repository structure, test scenarios, and setup instructions.

---

## **Project Structure**

```
SauceLabsAutomation
├── Drivers                # WebDriver executables (Chromedriver, Firefox, Opera)
├── Pages                 # Page Object Models (POMs)
├── Tests                 # Test cases
├── TestData              # External data sources (Xml)
├── Reports               # Test execution reports (ExtentReport)
└── README.md             # Project documentation
```

---

## **Test Scenarios**

### 1. **Login Functionality**
   - **Positive Test Case**: Verify login with valid credentials.
   - **Negative Test Cases**: 
     - Attempt login with invalid username.
     - Attempt login with invalid password.
     - Attempt login with empty fields.

### 2. **Product Sorting**
   - Validate that products can be sorted by:
     - Name (A to Z)
     - Name (Z to A)
     - Price (Low to High)
     - Price (High to Low)

### 3. **Add to Cart Functionality**
   - Add multiple products to the cart and verify:
     - Cart icon displays the correct count.
     - Products are listed correctly in the cart.

### 4. **Remove from Cart Functionality**
   - Remove items from the cart and ensure:
     - Cart count is updated.
     - Removed items are no longer listed in the cart.

### 5. **Checkout Process**
   - Complete the checkout process and validate:
     - Shipping information is required.
     - Payment confirmation page displays the correct total amount.

---

## **Technologies Used**

- **Programming Language**: C#
- **Testing Framework**: MsTest
- **Browser Automation Tool**: Selenium WebDriver
- **Reporting Tool**: Extent Reports
- **Build Tool**: MSBuild

---

## **Setup Instructions**

### Prerequisites
1. Install **Visual Studio** (with .NET support).
2. Install **NuGet Packages**:
   - Selenium.WebDriver
   - Selenium.WebDriver.ChromeDriver
   - MsTest
   - ExtentReports

### Steps to Run the Tests
1. Clone this repository:
   ```bash
   git clone https://github.com/username/SauceLabsAutomation.git
   ```

2. Open the solution file in Visual Studio.

3. Build the project to ensure all dependencies are installed.

4. Update the configuration file (`appsettings.json`) with:
   - Sauce Labs URL
   - Valid credentials
   - Browser settings

5. Run the test suite using NUnit Console or from Visual Studio Test Explorer.

6. View the test execution report in the `Reports` folder.

---

## **Sample Code Snippets**

### Login Test Case
```csharp
[Test]
public void LoginWithValidCredentials()
{
    LoginPage loginPage = new LoginPage(driver);
    loginPage.EnterUsername("standard_user");
    loginPage.EnterPassword("secret_sauce");
    loginPage.ClickLogin();

    Assert.IsTrue(ProductsPage.IsLoaded(), "Login failed, Products page not displayed.");
}
```

### Add to Cart Test Case
```csharp
[Test]
public void AddProductToCart()
{
    ProductsPage productsPage = new ProductsPage(driver);
    productsPage.AddToCart("Sauce Labs Backpack");

    Assert.AreEqual("1", CartIcon.GetCartCount(), "Cart count mismatch.");
}
```

---

## **Test Reporting**

After each test execution, an **Extent Report** is generated in the `Reports` folder. It includes:
- Test case status (Pass/Fail)
- Screenshots for failed test cases
- Execution time

---

## **Contributing**

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m "Add feature"`).
4. Push to the branch (`git push origin feature-name`).
5. Open a pull request.

---

---

## **Contact**

For questions or support, please contact: 
- **Hassan Mehmood**
- [LinkedIn Profile](https://www.linkedin.com/in/mhassanmehmood/)
