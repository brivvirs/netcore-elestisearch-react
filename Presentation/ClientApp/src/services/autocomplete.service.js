export const GetSections = async () => {
  const response = await fetch("/hints/sections");
  const result = (await response).json();
  return result;
};

export const GetHintWords = async (sectionId, pattern) => {
  const response = await fetch("/hints/getwords/" + sectionId + "/" + pattern);
  const result = (await response).json();
  return result;
};

export const AddNewSection = async title => {
  const response = await fetch("/hints/add/section/" + title);
  const result = (await response).json();
  return result;
};
