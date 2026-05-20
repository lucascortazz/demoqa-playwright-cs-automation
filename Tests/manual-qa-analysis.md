# Part 1 – Manual QA Analysis

## 1. Acceptance Criteria

- The page loads successfully and all form fields are visible.
- The user can enter values into Full Name, Email, Current Address, and Permanent Address fields.
- The Submit button is visible, enabled, and clickable.
- The form accepts valid input values and submits successfully.
- After submission, the output section is displayed.
- The displayed output values match exactly the submitted values.
- Invalid email formats trigger validation behavior.
- The page remains usable across common desktop and mobile screen resolutions.

---

## 2. Essential Test Cases

### Positive Scenarios

- Submit the form with valid values in all fields.
- Verify all submitted values are displayed correctly in the output section.
- Verify the Submit button works correctly after scrolling.

### Negative / Validation Scenarios

- Submit the form with an invalid email format.
- Submit the form with empty fields.
- Submit the form using only spaces in the input fields.
- Submit the form with special characters in the name and address fields.
- Submit the form with long text values to validate UI stability.

### Basic UI Scenarios

- Verify all fields, labels, and placeholders are displayed correctly.
- Verify the output section is not displayed before submission.
- Verify keyboard navigation and tab order work correctly.

---

## 3. Risks / Edge Cases

- Invalid email formats may be accepted incorrectly.
- Output values may not match the submitted values exactly due to formatting or spacing issues.
- Long text values may break the page layout or overflow the UI.
- Special characters may not render correctly.
- The Submit button may become hidden or blocked by dynamic page elements.
- Partial form submissions may behave inconsistently.
- Browser-specific rendering differences may affect functionality or layout.
- Dynamic ads or overlays on the page may interfere with interactions or automation stability.