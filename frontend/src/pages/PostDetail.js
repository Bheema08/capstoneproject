
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { blogPostService } from '../services/blogPosts';
import { Helmet } from 'react-helmet-async'; 

const PostDetail = () => {
  const [post, setPost] = useState(null);
  const [loading, setLoading] = useState(true);
  const { id } = useParams();

  useEffect(() => {
    const fetchPost = async () => {
      try {
        const data = await blogPostService.getById(id);
        setPost(data);
      } catch (error) {
        console.error('Error fetching post:', error);
        setPost(null); 
      } finally {
        setLoading(false);
      }
    };

    fetchPost();
  }, [id]);

  if (loading) return <div className="container mt-5 text-center"><div className="spinner-border text-primary" role="status"><span className="visually-hidden">Loading...</span></div></div>;
  if (!post) return <div className="container mt-5 text-center alert alert-warning">Post not found or an error occurred.</div>;

  return (
    <>
      <Helmet>
        <title>{post.title} - BlogCMS</title>
        <meta name="description" content={post.content.substring(0, 160).replace(/<[^>]*>?/gm, '') + '...'} />
        
      </Helmet>
      <div className="container mt-5 mb-5">
        <article className="bg-white p-4 p-md-5 rounded shadow-sm">
          <h1 className="display-4 mb-4 text-primary fw-bold text-center">{post.title}</h1>
          {post.featuredImageUrl && (
            <div className="text-center mb-4">
              <img 
                src={post.featuredImageUrl} 
                alt={post.title} 
                className="img-fluid rounded shadow-sm"
                style={{ maxHeight: '450px', objectFit: 'cover', width: '100%' }}
              />
            </div>
          )}
          <div className="text-muted mb-4 text-center">
            Posted by <span className="fw-bold">{post.author?.username || 'Unknown'}</span> on {new Date(post.publishedAt).toLocaleDateString()}
          </div>
          <div className="post-content lead" dangerouslySetInnerHTML={{ __html: post.content }} />
          {post.tags && (
            <div className="mt-5 pt-3 border-top">
              <strong className="text-primary">Tags:</strong> 
              <span className="badge bg-secondary ms-2 p-2">
                {post.tags.split(',').map(tag => tag.trim()).join(', ')}
              </span>
            </div>
          )}
        </article>
      </div>
    </>
  );
};

export default PostDetail;
