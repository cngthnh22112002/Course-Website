import { CourseWebsiteTemplatePage } from './app.po';

describe('CourseWebsite App', function() {
  let page: CourseWebsiteTemplatePage;

  beforeEach(() => {
    page = new CourseWebsiteTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
