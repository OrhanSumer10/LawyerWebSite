using EntityLayer.Concrete;

namespace MyLiveProject.Models
{
    public class ModelViewControl
    {
        public IEnumerable<Makale>? makalemodel { get; set; }    
        public IEnumerable<Dava>? Davamodel { get; set; }
        
        public IEnumerable<Contact>? Contactmodel { get; set; }    
        public IEnumerable<SubScribe>? Submodel { get; set; }    
        public IEnumerable<Admin>? Adminmodel { get; set; }    
    }
}
