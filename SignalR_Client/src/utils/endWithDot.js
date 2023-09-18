//This functions ensure a text to end with dot and not contain spaces at the end or beginning.
export default function endWithDot(text){
    // Delete Spaces
    const textNoSpaces = text.trim(); 
    // Check if text already ends with point.
    if (textNoSpaces.endsWith(".")) {
      return textNoSpaces;
    } else {
      return textNoSpaces + ".";
    }
}