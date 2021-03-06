using System;
using HtmlTags;

namespace ST.Docs.Samples
{
    public class SampleTag : HtmlTag
    {
        public SampleTag(Sample sample) : base("pre")
        {
            Add("code").AddClass("language-" + sample.Language).Text(Environment.NewLine + sample.Text);
        }
    }
}